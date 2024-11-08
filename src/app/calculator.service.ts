import { effect, Injectable, signal, WritableSignal } from '@angular/core';
import { create, all } from 'mathjs';

const math = create(all);

@Injectable({
  providedIn: 'root',
})
export class CalculatorService {
  private lastActionWasEvaluation = false;

  // Typen
  private numbers = '0123456789';
  private operators = '+-*/^';
  private parentheses = '()';

  // Den aktuellen Zustand aus dem Browser abrufen
  currentCalculation: WritableSignal<string> = signal(
    localStorage.getItem('currentCalculation') || '',
  );
  history: WritableSignal<string[]> = signal(
    JSON.parse(localStorage.getItem('history') || '[]'),
  );

  // #region constructor
  constructor() {
    // Den aktuellen Zustand im Browser speichern
    effect(() => {
      localStorage.setItem('currentCalculation', this.currentCalculation());
    });

    effect(() => {
      localStorage.setItem('history', JSON.stringify(this.history()));
    });

    // math.js (math.evaluate() Funktion) für präzisere Ergebnisse konfigurieren
    math.config({
      number: 'BigNumber',
      precision: 13,
    });
  }
  // #endregion

  addCharacter(char: string): void {
    let calc = this.currentCalculation();
    let lastChar = calc.slice(-1);

    // Wenn die letzte Aktion eine Auswertung war, Rechnung löschen
    if (this.lastActionWasEvaluation) {
      this.clear();
      calc = '';
    }

    // Verhindern, dass am Anfang der Rechnung ein Operator hinzugefügt wird

    // Weitere Ideen?

    // Füge das Zeichen zu calc hinzu
    calc += char;

    // Setze currentCalculation auf modifizierte calc variable
    this.currentCalculation.set(calc);
    this.lastActionWasEvaluation = false;
  }

  evaluate() {
    // Nur auswerten, wenn es etwas auszuwerten gibt
    if (this.currentCalculation() !== '') {
      try {
        let result = math.evaluate(this.currentCalculation());
        this.currentCalculation.set(result.toString());

        // Geteilt durch 0 besser handhaben

        // Das Resultat nur dem Verlauf hinzufügen, wenn es keine Fehler gab
        if (!['NaN', 'Infinity'].includes(this.currentCalculation())) {
          this.history.update((history) => {
            const newHistory = [this.currentCalculation(), ...history];
            // Verhindern, dass die Länge des Verlaufes nicht 10 Zeilen überschreitet
            if (newHistory.length > 10) {
              newHistory.pop();
            }
            return newHistory;
          });
          this.lastActionWasEvaluation = true;
        }
      } catch (e) {
        // Calculation-display rot erblitzen lassen
        const displayBackground =
          document.getElementById('display-background')!;
        displayBackground.classList.add('error');
        setTimeout(() => {
          displayBackground.classList.remove('error');
        }, 50);
        console.error(e);
      }
    }
  }

  addDecimalPoint() {
    // Die letzte nummer in der Rechnung holen (Bsp. 10.1)
    const lastNumber = this.currentCalculation()
      .split(/[+\-*\/^()]/)
      .pop();

    // Nur einen Dezimalpunkt hinzufügen, wenn die letzte Zahl noch keinen enthält.
    if (lastNumber && !lastNumber.includes('.')) {
      this.currentCalculation.set(this.currentCalculation() + '.');
    }
  }

  clear() {
    this.currentCalculation.set('');
  }

  clearEntry() {
    // Wenn das letzte Zeichen ein Operator ist, diesen löschen
    if (
      this.operators.includes(this.currentCalculation().slice(-1)) ||
      this.parentheses.includes(this.currentCalculation().slice(-1))
    ) {
      this.backspace();
    }

    // backspace() wiederholen, bis das letzte zeichen nicht mehr eine Zahl ist
    while (this.numbers.includes(this.currentCalculation().slice(-1))) {
      this.backspace();
      if (this.currentCalculation().slice(-1) === '') {
        break;
      }
    }
  }

  backspace() {
    // Wenn die letzte Auswertung zu Fehlern führte, Berechnung löschen
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

    // Die letzte nummer in der Rechnung holen (e.g. 10.1)
    const lastNumberRegex = /(-?\d+(?:\.\d+)?)$/;
    const match = calculation.match(lastNumberRegex);

    if (match) {
      const lastNumber = match[0];
      const index = match.index!;

      if (lastNumber.startsWith('-')) {
        this.currentCalculation.set(
          // Die Rechnung ohne Minuszeichen speichern
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
