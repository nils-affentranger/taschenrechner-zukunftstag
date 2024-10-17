import { effect, Injectable, signal, WritableSignal } from '@angular/core';
import { create, all, BigNumber } from 'mathjs';

const math = create(all)

@Injectable({
  providedIn: 'root'
})

export class CalculatorService {

  // Types
  private numbers = "0123456789";
  private operators = "+-*/^";
  private parentheses = "()";

  private lastActionWasEvaluation = false;

  // Get the current state from the browser
  currentCalculation: WritableSignal<string> = signal(localStorage.getItem('currentCalculation') || '');
  history: WritableSignal<string[]> = signal(JSON.parse(localStorage.getItem('history') || '[]'));

  constructor() {
    // Save the current state in the browser
    effect(() => {
      localStorage.setItem('currentCalculation', this.currentCalculation());
    });

    effect(() => {
      localStorage.setItem('history', JSON.stringify(this.history()));
    });

    // Enables keyboard input
    window.addEventListener('storage', (event) => {
      if (event.key === 'currentCalculation') {
        this.currentCalculation.set(event.newValue || '');
      } else if (event.key === 'history') {
        this.history.set(JSON.parse(event.newValue || '[]'));
      }
    });

    // Configure math.js for more precise results
    math.config({
      number: "BigNumber",
      precision: 13,
    });
  }

  // Determines the character's type - Helpful for validating inputs
  determineType(character: string): 'number' | 'operator' | 'parenthesis' | 'undefined' {
    if (this.numbers.includes(character)) {
      return 'number';
    } else if (this.operators.includes(character)) {
      return 'operator';
    } else if (this.parentheses.includes(character)) {
      return 'parenthesis';
    } else {
      console.error(`Unknown character: ${character}`);
      return 'undefined';
    }
  }

  addCharacter(char: string): void {
    let calc = this.currentCalculation();
    const lastChar = calc.slice(-1);

    if (['NaN', 'Infinity'].includes(calc)) {
      this.clear();
      calc = '';
    }

    if (calc === '' && char === '0') return;

    const type = this.determineType(char);

    if (this.lastActionWasEvaluation && (type === 'number')) {
      this.clear();
      calc = '';
    }

    // Operators
    if (type === 'operator') {
      if (lastChar === '.') return;
      if (calc === '') {
        this.currentCalculation.set('0' + char);
        return;
      }
      if (this.operators.includes(lastChar)) {
        this.backspace();
        calc = this.currentCalculation();
      }
    }

    // Parentheses
    if (char === '(' && lastChar === '.') {
      return;
    }

    if (char === '(' && calc && !this.operators.includes(lastChar) && !this.parentheses.includes(lastChar)) {
      calc += '*';
    }

    if (char === ')') {
      const openCount = (calc.match(/\(/g) || []).length;
      const closeCount = (calc.match(/\)/g) || []).length;
      if (closeCount >= openCount) return;
    }

    this.currentCalculation.set(calc + char);
    this.lastActionWasEvaluation = false;
  }


  evaluate() {
    if (this.currentCalculation() !== '0' && this.currentCalculation() !== '') {
      let error = false;
      try {
        let result = math.evaluate(this.currentCalculation());
        this.currentCalculation.set(result.toString());
      } catch (e) {
        const displayBackground = document.getElementById('display-background')!;
        // lässt den
        displayBackground.classList.add('error');
        setTimeout(() => {
          displayBackground.classList.remove('error');
        } , 50);
        console.error(e);
        error = true;
        return;
      } finally {
        if (!error && !['NaN', 'Infinity'].includes(this.currentCalculation())) {
          this.history.update(history => {
            const newHistory = [this.currentCalculation(), ...history];
            if (newHistory.length > 10) {
              newHistory.pop();
            }
            return newHistory
          });
          this.lastActionWasEvaluation = true;
        }
      }
    }
  }

  addDecimalPoint() {
    const lastChar = this.currentCalculation().slice(-1);
    if (this.currentCalculation() === '' || this.operators.includes(lastChar) || this.parentheses.includes(lastChar)) {
      this.currentCalculation.set(this.currentCalculation() + '0.');
    } else {
      const lastNumber = this.currentCalculation().split(/[+\-*\/^()]/).pop();
      if (lastNumber && !lastNumber.includes('.')) {
        this.currentCalculation.set(this.currentCalculation() + '.');
      }
    }
  }

  clear() {
    this.currentCalculation.set('');
  }

  clearEntry() {
    if (['NaN', 'Infinity'].includes(this.currentCalculation())) {
      this.clear();
      return;
    }
    while (this.numbers.includes(this.currentCalculation().slice(-1))) {
      this.backspace();
      if (this.currentCalculation() === '') {
        break;
      }
    }
    if (this.operators.includes(this.currentCalculation().slice(-1)) || this.parentheses.includes(this.currentCalculation().slice(-1))) {
      this.backspace();
    }
  }

  backspace() {
    if (['NaN', 'Infinity'].includes(this.currentCalculation())) {
      this.clear();
      return;
    }
    if (this.currentCalculation) {
      this.currentCalculation.set(this.currentCalculation().slice(0, -1));
    }
  }

  toggleSign() {
    let calculation = this.currentCalculation();
    if (calculation === '') return;

    // Findet die letzte Nummer in der Rechnung
    const lastNumberRegex = /(-?\d+(?:\.\d+)?)$/;
    const match = calculation.match(lastNumberRegex);

    if (match) {
      const lastNumber = match[0];
      const index = match.index!;

      if (lastNumber.startsWith('-')) {
        this.currentCalculation.set(
          calculation.slice(0, index) + lastNumber.slice(1)
        );
      } else {
        this.currentCalculation.set(
          calculation.slice(0, index) + '-' + lastNumber
        );
      }
    }
  }

  clearHistory() {
    this.history.set([]);
  }

}
