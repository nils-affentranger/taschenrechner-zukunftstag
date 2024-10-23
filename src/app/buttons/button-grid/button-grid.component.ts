import { Component, inject } from '@angular/core';
import { ButtonComponent } from '../button/button.component';
import { CalculatorService } from '../../calculator.service';

@Component({
  selector: 'app-button-grid',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './button-grid.component.html',
  styleUrl: './button-grid.component.scss',
})
export class ButtonGridComponent {
  calculatorService = inject(CalculatorService);
}
