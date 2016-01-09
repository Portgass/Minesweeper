Minesweeper
==========

Zadání
--------
Hra Minesweeper(hledání min), podporující více obtížností a herních módů.

**Specifikace**

Hra by měla být naprogramovaná tak, aby bylo snadné ji rozšířit o více obtížností a módů.   
Dále by mělo být snadné hru obohatit o více prvků, než tradiční hledání min.   
Do políček lze vložit více různých herních objektů, pro které by vytvoření nových mechanik je snadné.    
Reprezentace všech datových modelů(políček, hracího pole) s nimi není pevně spojena. Umožňuje to jednoduší změny zobrazení.

Algoritmy
------
Většina funkcí používá pouze procházení seznamu nebo pole a jednoduché příkazy.    
Toto je výběr pár složitějších funkcí.

**1. Odhalování políček**   
*Algoritmus používá Dictionaries pro přiřazení políčkům jejich odpovídající zobrazení v herním okně.*    
Nejdříve se zkontroluje, obsah políčka.    
Pokud obsahuje vlajku, políčko odhalit nelze, pokud minu, hra končí hráčovou prohrou.    
Jinak můžeme políčko odhalit a zaregistrovat jeho stav.   
Zjistíme počet okolních min a pokud není v okolí žádná, odhalíme i sousedící políčka.

**2. Přiřazování sousedících políček**   
Projede se pole všech políček na hrací desce.   
Pro každé políčko prozkoumáme jeho sousedy. Což znamená:   
Pokud má pole souřadnice x, z, prozkoumáváme pole x-1, y-1 - x+1, y+1 (kromě samotného x, y).
```
pole ... T
sousedi ... N
ostatní pole ... o
o o o o o
o N N N o
o N T N o
o N N N o
o o o o o
```
Výsledky se liší pro různé herní módy.

Normální mód operuje pouze s pozicemi na herní desce a hraničním polím přiřazuje ménně polí.
```
T N o o o
N N o o o
o o o o o
o o o o o
o o o o o
```
Extrémní mód řeší pozice mimo herní desku tak, že přiřadí jako souseda pole na opačné straně desky.
```
T N o N N
N N o o o
o o o o o
o o o o o
N N o o N
```

**3. Pokládání min**
Vytvoříme x náhodných čísel v rozmezí od 0 do počtu všech polí - 1. Chceme všechna čísla různá.    
Tato čísla se uloží v seznamu.    
Při procházení všech polí si zvyšujeme hodnotu nynějšího projití a ta se porovnává s hodnotami v seznamu.    
Jestli se obě hodnoty rovnají, umístíme do pole minu.    
Po umístění všech min projdeme všechny pole znovu a spočítáme sumu min ve všech sousedech polí.   

Program
------
Všechny hlavní komponenty programu jsou třídy, některé dědí vlastnosti z prvků Windows Forms. Celé zobrazení programu zajišťují Windows Forms.
Třídy obsahující data samotných prvků:
1. Coordinates - pomocná třída, která definuje jednotky používané programem.
2. Field - zná svou pozici, obsah a také všechny jeho sousedy.
3. Board - obsahuje pole všech polí a přiřazuje jim jejich prvky a pomáhá jim registrovat jejich sousedy.
Třídy zajišťující zobrazení prvků:
1. View - Zprostředkovává zobrazení oken a ukončení programu. MenuView a GameView dědí jeho vlastnosti.
2. MenuView - Zobrazuje menu, obsahuje tlačítka pro výběr obtížnosti a módu.
3. GameView - Zobrazuje hrací plochu, a informace o herním čase a použitelných vlajkách. Také zajišťuje okno po skončení hry.
4. MenuOption - Dědí z WinForms Button. Jsou mu nastaveny základní atributy pro zjednodušení nastování všech tlačítek menu.
5. FieldView - Zobrazení jednotlivých polí. Obstarává vzhled ovlajkovaných a odhalených polí.
Třídy zajišťující ovládání hry:
1. MenuController - Zajišťuje zpacování kliknutí na tlačítek menu a spouštění hry se správným nastavením.
2. GameController - Přiřazuje polím jejich zobrazení. Nastavuje chování hry po hráčových akcích. Kontroluje podmínky ukončení hry.

Ovládání
-----
Ukončení hry kdykoli v průběhu chodu pomocí X v pravo nahoře.   
V menu je zaškrtávací pole pro zvolení extrémního módu.   
Po kliknutí na obtížnost se spustí hra.   
V dolních rozích je čas od startu hry(nalevo) a dostupný počet vlaječek(napravo), což je i počet min na herní desce.   
Cílem hry je nalezení všech min označením všech políček obsahující minu vlajkou.   
Levé tlačítko myši odhaluje pole, pravé sází vlajku.   
Po odhalení pole se může zobrazit číslo reprezentující počet min v okolních polích. Pomocí těchto čísel lze určit polohy min.

Průběh práce
-----
Nejdříve jsem začínal se zobrazením hry, které celé probíhalo v konzoli, ale později jsem přešel na Windows Forms, které umožňují lepší zobrazení hry.    
Snažil jsem se po celou dobu tvorby, aby bylo možné program snadno rozšířit, ale zvláště ke konci se mi to už nedařilo. Některé věci nejsou ve stavu, který považuji za ideální.

Co nebylo doděláno
----
Některé třídy obsahují funkce, které by měli být rozloženy na více částí a umístěny zvlášť v jiných třídách.    
Také podpora dalších módů by šla zlepšit. Momentálně se počítá pouze s jedním, pokud by nějaký přibyl, některé natvrdo napsané funkce by bylo třeba přepsat.

Jak program přeložit
-----
Program lze přeložit ve Visual Studiu. Vytvořeno pro .NET Framework 4.5.2
