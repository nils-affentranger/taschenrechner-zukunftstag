import { Injectable, signal, WritableSignal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  result: WritableSignal<string> = signal('0');

  setResult(value: string): void {
    this.result.set(value || '0');
  }

  getResult(): string {
    return this.result();
  }
}
