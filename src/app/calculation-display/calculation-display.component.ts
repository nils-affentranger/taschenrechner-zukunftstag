import { Component, effect, inject } from "@angular/core";
import { CalculatorService } from "../calculator.service";

@Component({
  selector: "app-calculation-display",
  templateUrl: "./calculation-display.component.html",
  styleUrl: "./calculation-display.component.scss",
})
export class CalculationDisplayComponent {
  private calculatorService = inject(CalculatorService);

  currentCalculation = "";

  constructor() {
    effect(() => {
      this.currentCalculation = this.calculatorService.currentCalculation();
    });
  }
}
