# Protokoll

Betrachtet die Source-Code-Dateien FamilyTree.cs und Program.cs. In Familytree wird eine Datenstruktur aufgebaut, die eine Art Familienstammbaum repräsentiert (Ähnlichkeiten mit realen Personen sind rein zufällig :-)).

Macht euch klar, dass die Datenstruktur Person rekursiv ist, denn jedes Objekt vom Typ Person referenziert zwei weitere Objekte vom Typ Person, nämlich Mom und Dad.

Die Methdode BuildTree() baut einen Beispiel-Baum auf. Setzt einen Breakpoint in Zeile 19 von Program.cs, startet den Debugger und seht Euch den Inhalt von root im Debugger an.

Die Methode Find() durchläuft rekursiv den Baum und prüft alle Person-Objekte darauf, ob die Bedingung in Zeile 22 gegeben ist. Die erste Person, die die Bedingung erfüllt, wird zurückgeliefert.

Ändert die Bedingung so, dass nicht gleich die erste Person ("Willi") zurückgegeben wird. Eventuell gibt es Abstürze. Analysiert die Abstürze mit dem Debugger, überprüft Variableninhalte und den Call-Stack.

Schreibt komplexere Bedingungen, findet z.B. die erste Person, die in einer Altersspanne liegt, vergleicht dazu person.DateOfBirth.Year mit DateTime.Now.Year. Analysiert mit dem Debugger, ob Eure Bedingung richtig ist.