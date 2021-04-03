# <b>INTEGRUOTOS PROGRAMAVIMO APLINKOS</b>

## <b>3-4 Laboratorinis darbas</b>

<b>Programos naudojimasis</b>

Paleisti programą ir sekti meniu nurodymus

<b>Atliktos užduoties ir jos rezultatu dokumentacija</b>

## <b>Release v0.1</b>

Pridėtos funkcijos:

- Studento pridėjimas per konsole pasirenkant: namų darbų ir egzamino pažymius sistemą pati sugeneruos ar ves vartotojas.
- Studentu atvaizdavimas lentelės pavidalų (atkartojant duota pvz)

## <b>Release v0.2</b>

Pridėtos funkcijos:

- Studentų importas į programą iš `students.csv` file.
- Patobulintas Studentu atvaizdavimas. Lentelėje dabar studentai yra rušiuojami pagal vardą.

## <b>Release v0.3</b>

Pridėtos funkcijos:

- Kur įmanoma buvo pritaikytas išimčių (angl. Exceptions) apdorojimas.
- Pagalbinės funkcijos susijusios su studentais buvo iškeltos į StudentUtils.cs failą.

## <b>Release v0.4</b>

Pridėtos funkcijos:

- Atsitiktinių studentų generavimas
- Atsirado PerfMeasuringUtil.cs, kurioje talpinamos visos pagalbines funkcijos susijusios su programos greitaveikos matavimais.
- Funkcija, kuri matuoją ir pateikia laika uždelsta 10000, 100000, 1000000 ir 10000000 studentų sugeneravimui ir išskaidimui į 2 `.csv` failus atsižvelgiant į studento baigiamąjį.

<b>Našumo testavimo rezultatai:</b>

![plot](ReadmeImages/PerfResults_generatingAndSplitting.png?raw=true 'Našumo testavimo rezultatai')

## <b>Release v0.5</b>

Pridėtos funkcijos:

- Metodai suteikiantis galimybę atlikti tapati našumo testavimą kaip release_v0.4 su skirtingomis kolekcijomis
- Funkciją, kuri importuoja tuos pačius testinius failus su studentais ir juos saugo programoje naudojant `List<>`, `LinkedList<>` ir `Queue<>` kolekcijas. Toliau, išmatuoja ir pateikia uždelsto laiko skaičių importuotų duomenų išrūšiavimui į dvi grupes ir rūšiavimo rezultat7 išsaugojimo į du atskirus `.csv` failus atsižvelgiant į studento galūtinį rezultatą.

<b>Našumo testavimo rezultatai:</b>

![plot](ReadmeImages/PerfResults_containers.png?raw=true 'Našumo testavimo rezultatai')

<b>Rezultatai:</b>

- `List<>` kolekciją su beveik kiekvienų duomenų kiekių buvo paskutine tarp trijų lygintu kolekcijų
- `LinkedList<>` Yra optimalus variantas kai duomenų yra maži kiekiai 10-100 tukst.
- `Queue<>` Yra geriausias variantas dirbant su didėliais duomenų kiekiais

## <b>Release v1.0</b>

Buvo bandoma optimizuoti egzistuojanti iš v0.5 studentų rušiavima pasitelkiant 2 žemiau aprašytas strategijas

- <b>1. Strategija</b> Studentus kolekcijoje turinčius teigiamus ir neigiamus galutinius pažymius išrušiuoti į dvi tokio pačio tipo kolekcijas.

- <b>2. Strategija</b> Studentus turinčius teigiamus pažymius perkelti į nauja tokio pačio tipo kolekciją ir ištrinti iš pagrindinio sąrašo.

<b>Našumo testavimo rezultatai:</b>

![plot](ReadmeImages/PerfResults_Strategies.png?raw=true 'Našumo testavimo rezultatai')

<b>Rezultatai:</b>

- Pirma strategija beveik visais atvėjais buvo greitesne už antrą strategiją. Išimtimi buvo `Linkedlist` kolekciją, kuri 1000000 ir 10000000 atvėjais buvo letėsne už 2 strategija
- Antros strategijos atminties naudojimas yra žymiai mažesnis, tačiau duomenų greitis yra irgi letėsnis. Ypač tai pastebima su `Queue` kolekcija (visada žymiai letėsne 2 strategiją) ir `Linkedlist` kolekcija, kurios atvėju su dideliais duomenų kiekiais pradėda smarkiai kristi duomenų apdorojimo greitis.
  `List` kolekcijos atvėju greičio praradimas yra nežymus su visais duomenų kiekiais ir jį atperka mažesnes atminties sąnaudos.
