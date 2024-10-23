import { Component, HostListener, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CalculationDisplayComponent } from './calculation-display/calculation-display.component';
import { HistoryBoxComponent } from './history-box/history-box.component';
import { ButtonGridComponent } from './buttons/button-grid/button-grid.component';
import { KeybindsDisplayComponent } from './keybinds-display/keybinds-display.component';
import { KeyboardService } from './keyboard.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    CalculationDisplayComponent,
    ButtonGridComponent,
    HistoryBoxComponent,
    KeybindsDisplayComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  keyboardService = inject(KeyboardService);

  keybindsAreVisible = false;

  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.ctrlKey && event.shiftKey && event.key === 'K') {
      this.toggleVisibility();
    }
    if (!this.keybindsAreVisible) {
      this.keyboardService.handleKeyboardEvent(event);
    }
  }
  toggleVisibility() {
    const keybindsDisplay = document.getElementById('keybinds-display');
    const overlay = document.getElementById('overlay');
    this.keybindsAreVisible = !this.keybindsAreVisible;

    if (keybindsDisplay) {
      keybindsDisplay.classList.toggle('visible');
      keybindsDisplay.style.pointerEvents = keybindsDisplay.classList.contains(
        'visible',
      )
        ? 'auto'
        : 'none';
    }

    if (overlay) {
      overlay.classList.toggle('visible');
      overlay.style.pointerEvents = overlay.classList.contains('visible')
        ? 'auto'
        : 'none';
    }
  }
}
