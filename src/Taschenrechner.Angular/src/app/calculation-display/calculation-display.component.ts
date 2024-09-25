import {Component, effect, HostListener, inject, OnInit} from '@angular/core';
import {CalculatorService} from "../calculator.service";
import {NgScrollbar} from "ngx-scrollbar";

@Component({
  selector: 'app-calculation-display',
  standalone: true,
  imports: [
    NgScrollbar
  ],
  templateUrl: './calculation-display.component.html',
  styleUrl: './calculation-display.component.scss'
})
export class CalculationDisplayComponent {

  currentCalculation: string = '';

  private calculatorService = inject(CalculatorService)

  constructor() {
    effect(() => {
      this.currentCalculation = this.calculatorService.result();});
  }
}
