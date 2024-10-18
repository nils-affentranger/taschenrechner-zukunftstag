import { effect, Injectable, signal, WritableSignal } from '@angular/core';
import { create, all } from 'mathjs';

const math = create(all);

@Injectable({
  providedIn: 'root',
})
export class CalculatorService {
  // Types
  private numbers = '0123456789';
  private operators = '+-*/^';
  private parentheses = '()';

  private lastActionWasEvaluation = false;

  // Get the current state from the browser
  currentCalculation: WritableSignal<string> = signal(
    localStorage.getItem('currentCalculation') || '',
  );
  history: WritableSignal<string[]> = signal(
    JSON.parse(localStorage.getItem('history') || '[]'),
  );

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
      number: 'BigNumber',
      precision: 13,
    });
  }

  // Determines the character's type - Helpful for validating inputs
  determineType(
    character: string,
  ): 'number' | 'operator' | 'parenthesis' | 'undefined' {
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
    let lastChar = calc.slice(-1);

    // If last action was evaluation, clear calculation
    if (this.lastActionWasEvaluation) {
      this.clear();
      calc = '';
    }

    // Add input character to calc
    calc += char;

    // Set currentCalculation to modified calc
    this.currentCalculation.set(calc);
    this.lastActionWasEvaluation = false;
  }

  evaluate() {
    // Only evaluate when there is something to evaluate
    if (this.currentCalculation() !== '') {
      let error = false;
      try {
        let result = math.evaluate(this.currentCalculation());
        this.currentCalculation.set(result.toString());
      } catch (e) {
        // Flash calculation-display red
        const displayBackground =
          document.getElementById('display-background')!;
        displayBackground.classList.add('error');
        setTimeout(() => {
          displayBackground.classList.remove('error');
        }, 50);
        // Log error
        console.error(e);
        error = true;
        return;
      } finally {
        // Add result to history, only when there were no errors
        if (
          !error &&
          !['NaN', 'Infinity'].includes(this.currentCalculation())
        ) {
          this.history.update((history) => {
            const newHistory = [this.currentCalculation(), ...history];
            // Prevent history from exceeding 10 items
            if (newHistory.length > 10) {
              newHistory.pop();
            }
            return newHistory;
          });
          this.lastActionWasEvaluation = true;
        }
      }
    }
  }

  addDecimalPoint() {
    // Get the last number (e.g. 10.1)
    const lastNumber = this.currentCalculation()
      .split(/[+\-*\/^()]/)
      .pop();
    // Only add decimal point if the number doesn't include one already.
    if (lastNumber && !lastNumber.includes('.')) {
      this.currentCalculation.set(this.currentCalculation() + '.');
    }
  }

  clear() {
    this.currentCalculation.set('');
  }

  clearEntry() {
    // If last evaluation resulted in errors, clear calculation
    if (['NaN', 'Infinity'].includes(this.currentCalculation())) {
      this.clear();
      return;
    }
    // If the last character is an operator, delete it
    if (
      this.operators.includes(this.currentCalculation().slice(-1)) ||
      this.parentheses.includes(this.currentCalculation().slice(-1))
    ) {
      this.backspace();
    }
    // Repeat backspace() until the character isn't a number
    while (this.numbers.includes(this.currentCalculation().slice(-1))) {
      this.backspace();
      if (this.currentCalculation() === '') {
        break;
      }
    }
  }

  backspace() {
    // If last evaluation resulted in errors, clear calculation
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

    // Get last number in the calculation
    const lastNumberRegex = /(-?\d+(?:\.\d+)?)$/;
    const match = calculation.match(lastNumberRegex);

    if (match) {
      const lastNumber = match[0];
      const index = match.index!;

      if (lastNumber.startsWith('-')) {
        this.currentCalculation.set(
          // Remove the minus sign      ∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨
          calculation.slice(0, index) + lastNumber.slice(1),
        );
      } else {
        this.currentCalculation.set(
          calculation.slice(0, index) + '-' + lastNumber,
        );
      }
    }
  }

  clearHistory() {
    this.history.set([]);
  }
}
