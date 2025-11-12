# Taschenrechner - Zukunftstag exanic 2025

> Ihr dürft gerne Google verwenden, wenn ihr nicht weiter kommt. Natürlich könnt ihr auch jederzeit uns fragen.

### Challenge 1

Bei der zweituntersten Reihe von Knöpfen fehlt der Text (1, 2, 3, +).

Datei: [button-grid.component.html](./src/app/buttons/button-grid/button-grid.component.html)

---

### Challenge 2

Ein Knopf macht noch nichts. Erweitert diesen Knopf so, dass beim Klicken ein Plus zur Rechnung hinzugefügt wird.

---

### Challenge 3

Die Beschriftung der Knöpfe kann man kaum lesen, da die Textfarbe zu wenig Kontrast zu der Hintergrundfarbe hat. Ändert die Textfarbe, damit der Text besser lesbar ist.

Datei: [button.component.scss](./src/app/buttons/button/button.component.scss)

---

### Challenge 4

In der Box zwischen den Knöpfen und der Nummernanzeige gibt es in der oberen linken Ecke einen kleinen Knopf.  
Was macht dieser Knopf? Probiert es mal aus!

Die Benutzer deines Taschenrechners sollten wissen, was dieser Knopf macht, sobald sie ihn sehen.  
Fügt dazu das Symbol `assets/clear.svg` in den Knopf [clear-history-button.component.html](/src/app/history-box/clear-history-button/clear-history-button.component.html) ein.

> 💡 Verwendet dafür `<img src="">`.

---

### Challenge 5

Zur Zeit werden die Knöpfe nicht erhellt, wenn man darüber "hovert".
Findet die Style-Datei der Knöpfe und passt sie so an, dass diese heller werden, wenn man mit der Maus darüber fährt. 

### Challenge 6

Im Moment erlaubt der Rechner, dass ein Operator (+, -, ×, ÷) am Anfang der Rechnung stehen kann.  
Beispiel: `*2+2` ist keine gültige Rechnung. Findet heraus, wie man das verhindern kann.

Datei: [calculator.service.ts](/src/app/calculator.service.ts)

> 💡 Bearbeitet die Funktion, die ausgeführt wird, wenn ein Knopf gedrückt wird.

Verwendet dazu ein `if`-Statement. Beispiel:

```ts
if (rechnung == leer) {
  ...
}
```

> 💡 `return` "beendet" die Funktion.
