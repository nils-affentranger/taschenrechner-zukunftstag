import { Component, inject } from '@angular/core';
import { CalculatorService } from '../../calculator.service';

@Component({
    selector: 'app-clear-history-button',
    imports: [],
    templateUrl: './clear-history-button.component.html',
    styleUrl: './clear-history-button.component.scss'
})
export class ClearHistoryButtonComponent {

  private calculatorService = inject(CalculatorService);

  onClick() {
    this.calculatorService.clearHistory();
    console.log('History cleared');
  }
}
