import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CalculationDisplayComponent } from './calculation-display/calculation-display.component';
import { ButtonGridComponent } from './buttons/button-grid/button-grid.component';
import {HistoryBoxComponent} from "./history-box/history-box.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, CalculationDisplayComponent, ButtonGridComponent, HistoryBoxComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Taschenrechner';
}
