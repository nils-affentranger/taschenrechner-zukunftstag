import {HostListener, inject, Injectable} from '@angular/core';
import {CalculatorService} from "./calculator.service";

@Injectable({
  providedIn: 'root'
})
export class KeyboardService {


  constructor(private calculatorService: CalculatorService) {}

    handleKeyboardEvent(event: KeyboardEvent) {
    let character = '';
    switch (event.key) {
      case '0':
        character = '0';
        break;
      case '1':
        character = '1';
        break;
      case '2':
        character = '2';
        break;
      case '3':
        character = '3';
        break;
      case '4':
        character = '4';
        break;
      case '5':
        character = '5';
        break;
      case '6':
        character = '6';
        break;
      case '7':
        character = '7';
        break;
      case '8':
        character = '8';
        break;
      case '9':
        character = '9';
        break;
      case '+':
        character = '+'
        break;
      case '-':
        character = '-';
        break;
      case '*':
        character = '*';
        break;
      case '^':
        character = '^';
        break;
      case '/':
        character = '/';
        break;
      case '(':
        character = '(';
        break;
      case ')':
        character = ')';
        break;
      case '.':
        this.calculatorService.addDecimalPoint();
        return;
      case '=':
        this.calculatorService.evaluate();
        return;
      case 'Enter':
        event.preventDefault()
        this.calculatorService.evaluate();
        return;
      case 'Backspace':
        if (event.ctrlKey) {
          this.calculatorService.clearEntry();
        } else {
          this.calculatorService.backspace();
        }
        return;
      case 'Escape':
        this.calculatorService.clear();
        return;
      case 'H':
        if (event.ctrlKey && event.shiftKey) {
          this.calculatorService.clearHistory();
        }
        return;
      default:
        return;
    }
    this.calculatorService.addCharacter(character);
  }
}
