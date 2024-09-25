import {Component, inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CalculationDisplayComponent } from './calculation-display/calculation-display.component';
import { HistoryBoxComponent } from "./history-box/history-box.component";
import { ButtonGridComponent } from './buttons/button-grid/button-grid.component';
import {CalculatorService} from "./calculator.service";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, CalculationDisplayComponent, ButtonGridComponent, HistoryBoxComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Taschenrechner';

  calculatorService = inject(CalculatorService);

  ngOnInit() {
    this.calculatorService.getHistory();
    this.calculatorService.getCalculation();
  }
}
