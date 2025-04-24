# Praca Inżynierska – Gra VR w Unity

**Autor:** Karolina Sumowska  
**Uczelnia:** Uniwersytet Mikołaja Kopernika w Toruniu  
**Kierunek:** Informatyka  
**Temat pracy inżynierskiej:** Gra VR na gogle Meta Quest 3 z użyciem silnika Unity

---

## Opis projektu

Projekt stanowi grę VR opracowaną w ramach pracy inżynierskiej, zbudowaną w silniku **Unity 2022.3.40f1 (LTS)**. Aplikacja jest uruchamiana przy pomocy gogli **Meta Quest 3** połączonych z komputerem przy użyciu aplikacji **Meta Quest Link**.

---

## Wymagania

- **Unity**: Wersja `2022.3.40f1 (LTS)`
- **Gogle VR**: Meta Quest 3
- **Aplikacja**: Meta Quest Link zainstalowana na komputerze
- **Tryb deweloperski** włączony na goglach

---

## Konfiguracja Unity

Projekt został przygotowany z domyślnymi ustawieniami dla platformy **PC, Mac & Linux Standalone** z wykorzystaniem **OpenXR**.

Aby upewnić się, że środowisko zostało poprawnie skonfigurowane:

1. Przejdź do `Edit > Project Settings > XR Plug-in Management`.
2. W zakładce *Plug-in Providers* włącz **OpenXR**.
3. W `Build Settings` wybierz platformę: **PC, Mac & Linux Standalone**.
4. W sekcji `Project Settings` zaznacz **OpenXR** jako aktywne środowisko XR.
5. W ustawieniach OpenXR wybierz **Meta Quest Link** jako domyślny runtime.

## Budowanie projektu

Aby przygotować finalną wersję gry:

1. W Unity przejdź do `File > Build Settings`.
2. Wybierz platformę **PC, Mac & Linux Standalone**.
3. Kliknij przycisk **Build**.
4. Wskaż folder docelowy, w którym zostanie wygenerowany plik `.exe`.
5. Po zakończeniu procesu uruchom grę – upewnij się wcześniej, że gogle są podłączone i aktywne w aplikacji **Meta Quest Link**.


## Testowanie w edytorze Unity (tryb deweloperski)

Na etapie rozwoju projektu możliwe jest szybkie testowanie poszczególnych scen bez konieczności każdorazowego budowania pełnej wersji aplikacji. Unity umożliwia uruchomienie gry bezpośrednio z poziomu edytora, co znacząco przyspiesza proces iteracyjnego projektowania i weryfikacji działania poszczególnych elementów:

1. W Unity przejdź do folderu `Assets/Scenes/`.
2. Otwórz scenę główną: **StartScene**.
3. Upewnij się, że gogle są podłączone i wykryte przez system.
4. Naciśnij przycisk **Play**, aby uruchomić grę bezpośrednio w edytorze Unity.
5. Obraz zostanie przesłany do gogli w czasie rzeczywistym.

---

## Rozwiązywanie problemów

- **Gogle Meta Quest 3 nie są widoczne w Unity**  
    Upewnij się, że włączono *Tryb deweloperski* oraz że gogle są połączone przez kabel USB-C lub air link i zatwierdzono połączenie w interfejsie urządzenia.

- **Gra nie uruchamia się w goglach**  
    Zweryfikuj, czy aplikacja **Meta Quest Link** działa, a **OpenXR** jest ustawiony jako domyślny runtime w systemie.

- **Problemy z paczkami Unity**  
    W razie problemów z brakującymi zależnościami, porównaj plik `Packages/manifest.json` z oryginalnym repozytorium lub użyj `Unity Package Manager`, aby ręcznie zainstalować brakujące paczki.

---

**Karolina Sumowska**  
Rok: 2025  
Uniwersytet Mikołaja Kopernika w Toruniu  
*Projekt zrealizowany w ramach pracy inżynierskiej*

---

