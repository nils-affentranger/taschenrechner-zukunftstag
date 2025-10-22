import { Component, effect, inject } from "@angular/core";
import { CalculatorService } from "../calculator.service";
import { ClearHistoryButtonComponent } from "./clear-history-button/clear-history-button.component";

@Component({
  selector: "app-history-box",
  imports: [ClearHistoryButtonComponent],
  templateUrl: "./history-box.component.html",
  styleUrl: "./history-box.component.scss",
})
export class HistoryBoxComponent {
  history: string = "";

  private calculatorService = inject(CalculatorService);

  constructor() {
    effect(() => {
      this.history = this.calculatorService.history().join("<br>");
    });
  }
}
