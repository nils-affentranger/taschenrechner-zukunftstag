import { Injectable, signal, WritableSignal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  result: WritableSignal<string> = signal('');

  setResult(value: string): void {
    this.result.set(value);
  }

  getResult(): string {
    return this.result();
  }
}
