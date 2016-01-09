Minesweeper
==========

Zadání
--------
Hra Minesweeper(hledání min), podporující více obtížností a herních módů.

**Specifikace**

Hra by měla být naprogramovaná tak, aby bylo snadné ji rozšířit o více obtížností a módů.
Dále bz mělo být snadné hru obohatit o více prvků, než tradiční hledání min.
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
