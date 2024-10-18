import { Component } from '@angular/core';
import { KeybindElementComponent } from './keybind-element/keybind-element.component';

@Component({
  selector: 'app-keybinds-display',
  standalone: true,
  imports: [KeybindElementComponent],
  templateUrl: './keybinds-display.component.html',
  styleUrl: './keybinds-display.component.scss',
})
export class KeybindsDisplayComponent {}
