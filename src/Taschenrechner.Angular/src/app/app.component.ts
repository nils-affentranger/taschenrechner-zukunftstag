import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CalculationDisplayComponent } from './calculation-display/calculation-display.component';
import { HistoryBoxComponent } from "./history-box/history-box.component";
import { ButtonGridComponent } from './buttons/button-grid/button-grid.component';
import {KeybindsDisplayComponent} from "./keybinds-display/keybinds-display.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, CalculationDisplayComponent, ButtonGridComponent, HistoryBoxComponent, KeybindsDisplayComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.ctrlKey && event.shiftKey && event.key === 'K') {
      this.toggleVisibility();
    }
  }

  toggleVisibility() {
    const keybindsDisplay = document.getElementById('keybinds-display');
    const overlay = document.getElementById('overlay');

    if (keybindsDisplay) {
      keybindsDisplay.classList.toggle('visible');
      keybindsDisplay.style.pointerEvents = keybindsDisplay.classList.contains('visible') ? 'auto' : 'none';
    }

    if (overlay) {
      overlay.classList.toggle('visible');
      overlay.style.pointerEvents = overlay.classList.contains('visible') ? 'auto' : 'none';
    }
  }
}
