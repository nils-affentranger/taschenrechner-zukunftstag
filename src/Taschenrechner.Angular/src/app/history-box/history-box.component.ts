import {Component, effect, inject} from '@angular/core';
import { CalculatorService } from "../calculator.service";
import {NgScrollbarModule} from "ngx-scrollbar";

@Component({
  selector: 'app-history-box',
  standalone: true,
  imports: [NgScrollbarModule],
  templateUrl: './history-box.component.html',
  styleUrl: './history-box.component.scss'
})
export class HistoryBoxComponent {

  history: string = '';

  private calculatorService = inject(CalculatorService)

  constructor() {
    effect(() => {
      this.history = this.calculatorService.history();});
  }

}
