import {inject, Injectable, signal, WritableSignal} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  result: WritableSignal<string> = signal('0');
  history: WritableSignal<string> = signal('');

  http = inject(HttpClient)

  setResult(value: string): void {
    this.result.set(value || '0');
  }

  setHistory(value: string): void {
    this.history.set(value);
  }

  addCharacter(character: string) {
    this.http.post<{Response: string }>(
      'http://localhost:3085/api/calculator/addcharacter',
      { Character: character },
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        this.setResult(response.Response);
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
          this.setResult(response.Response);
          this.getHistory();
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
        this.setResult(response.Response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

  clear() {
    this.http.post<{Response: string}>(
      'http://localhost:3085/api/calculator/clear',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        this.setResult(response.Response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

  ClearEntry() {
    this.http.post<{Response: string}>(
      'http://localhost:3085/api/calculator/ce',
      {},
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        this.setResult(response.Response);
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
        this.setResult(response.Response);
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
        this.setResult(response.Response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

  getHistory() {
    this.http.post<{Response: string }>(
      'http://localhost:3085/api/calculator/gethistory',
      { Separator: "<br>" },
      { withCredentials: true }
    ).subscribe({
      next: (response) => {
        this.setHistory(response.Response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    });
  }

  setMaxHistoryLength() {
    this.http.post<{ Response: string }>(
      'http://localhost:3085/api/calculator/changemaxhistorylength',
      {Character: 100},
      {withCredentials: true}
    ).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    });
  }

  clearHistory() {
    this.http.post<{ Response: string }>(
      'http://localhost:3085/api/calculator/clearhistory',
      {},
      {withCredentials: true}
    ).subscribe({
      next: (response) => {
        console.log(response.Response);
        this.setHistory(response.Response);
      },
      error: (err) => {
        console.log("Error:", err);
      }
    })
  }

}
