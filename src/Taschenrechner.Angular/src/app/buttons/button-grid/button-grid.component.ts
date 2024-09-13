import {Component, HostListener, inject, OnInit} from '@angular/core';
import { ButtonComponent } from '../button/button.component';
import {CalculatorService} from "../../calculator.service";

@Component({
  selector: 'app-button-grid',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './button-grid.component.html',
  styleUrl: './button-grid.component.scss'
})
export class ButtonGridComponent implements OnInit{

  calculatorService = inject(CalculatorService);


  ngOnInit() {
    this.calculatorService.getHistory();
    this.calculatorService.setMaxHistoryLength();
  }

  @HostListener('document:keydown', ['$event'])
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
        this.calculatorService.evaluate();
        return;
      case 'Backspace':
        this.calculatorService.backspace();
        return;
      case 'Escape':
        this.calculatorService.clear();
        return;
      default:
        return;
    }
    this.calculatorService.addCharacter(character);
  }
}
