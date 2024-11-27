# Taschenrechner - Zukunftstag Exanic 2024

### Challenge 1

Bei der zweituntersten Reihe von Knöpfen fehlt der Text (1, 2, 3, +).

Datei: [button-grid.component.html](./src/app/buttons/button-grid/button-grid.component.html)

---

### Challenge 2

Ein Knopf ist noch leer. Erweitere diesen Knopf so, dass beim Klicken ein Plus zur Rechnung hinzugefügt wird.

---

### Challenge 3

Die Knöpfe passen farblich noch nicht. Setze den Hintergrund (`background: "farbe"`) der Knöpfe auf `#a25bb3` und passe die Textfarbe (`color: "farbe"`) so an, dass sie zum Hintergrund passt.

Datei: [button.component.scss](./src/app/buttons/button/button.component.scss)

---

### Challenge 4

In der Box zwischen den Knöpfen und der Nummernanzeige hast du vielleicht in der oberen linken Ecke einen kleinen Knopf entdeckt.  
Was macht dieser Knopf? Probiere es mal aus!

Die Benutzer deines Taschenrechners sollten wissen, was dieser Knopf macht, sobald sie ihn sehen.  
Füge dazu das Symbol `assets/clear-svgrepo-com.svg` in den Knopf [clear-history-button.component.html](/src/app/history-box/clear-history-button/clear-history-button.component.html) ein.

> 💡 Verwende dafür `<img src="">`.

---

### Challenge 5

Im Moment erlaubt der Rechner, dass ein Operator (+, -, ×, ÷) am Anfang der Rechnung stehen kann.  
Beispiel: `*2+2` ist keine gültige Rechnung. Finde heraus, wie du das verhindern kannst.

Datei: [calculator.service.ts](/src/app/calculator.service.ts)

> 💡 Bearbeite die `addCharacter()`-Funktion.

Verwende dazu ein `if`-Statement. Beispiel:

```ts
if (rechnung == leer) {
   return;
}
```

> 💡 `return` beendet die Funktion.