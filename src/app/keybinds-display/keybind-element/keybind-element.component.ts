import { Component } from '@angular/core';
import { KeyComponent } from './key/key.component';

@Component({
    selector: 'app-keybind-element',
    imports: [KeyComponent],
    templateUrl: './keybind-element.component.html',
    styleUrl: './keybind-element.component.scss'
})
export class KeybindElementComponent {}
