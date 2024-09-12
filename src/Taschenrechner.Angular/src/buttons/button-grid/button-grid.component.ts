import {Component, HostListener, inject} from '@angular/core';
import { ButtonComponent } from '../button/button.component';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Component({
  selector: 'app-button-grid',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './button-grid.component.html',
  styleUrl: './button-grid.component.scss'
})
export class ButtonGridComponent {

  http = inject(HttpClient)

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
        this.toggleSign();
        return;
      case '=':
        this.evaluate();
        return;
      case 'Enter':
        this.evaluate();
        return;
      case 'Backspace':
        this.backspace();
        return;
      case 'Escape':
        this.clear();
        return;
      default:
        return;
    }
    this.addCharacter(character);
  }

  result: string = '0';

  addCharacter(character: string) {
    this.http.post<{Response: string }>(
      'http://localhost:3085/api/calculator/addcharacter',
      { Character: character },
      { withCredentials: true }
    ).subscribe({
        next: (response) => {

          console.log("Response:", response);
        },
        error: (err) => {
          console.log("Error:", err);
        }
    });
  }

  evaluate() {
    this.http.post<{Response: string }>(
      'http://localhost:3085/api/calculator/evaluate',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        console.log("Response:", response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    }
    )
  }

  addDecimalPoint() {
    this.http.post<{ Response: string}>(
      'http://localhost:3085/api/calculator/adddecimalpoint',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        console.log("Response:", response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
    console.log("added decimal point")
  }

  clear() {
    this.http.post<{Response: string}>(
      'http://localhost:3085/api/calculator/clear',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        console.log("Response:", response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

  CE() {
    this.http.post<{Response: string}>(
      'http://localhost:3085/api/calculator/ce',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        console.log("Response:", response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

  backspace() {
    this.http.post<{Response: string}>(
      'http://localhost:3085/api/calculator/backspace',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        console.log("Response:", response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

  toggleSign() {
    this.http.post<{Response: string}>(
      'http://localhost:3085/api/calculator/togglesign',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        console.log("Response:", response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }
}
