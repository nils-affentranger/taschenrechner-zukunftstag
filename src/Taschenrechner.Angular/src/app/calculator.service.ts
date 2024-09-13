import { Injectable, signal, WritableSignal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  result: WritableSignal<string> = signal('0');
  history: WritableSignal<string> = signal('');

  setResult(value: string): void {
    this.result.set(value || '0');
  }

  setHistory(value: string): void {
    this.history.set(value);
  }

}
