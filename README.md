# Praca Inżynierska – Gra VR w Unity

**Autor:** Karolina Sumowska  
**Uczelnia:** Uniwersytet Mikołaja Kopernika w Toruniu  
**Kierunek:** Informatyka  
**Temat pracy inżynierskiej:** Projekt i implementacja interaktywnego doświadczenia wirtualnej rzeczywistości w formie „escape roomu” w środowisku Unity na urządzenia Meta Quest 3

---

## Opis projektu

Projekt stanowi grę VR opracowaną w ramach pracy inżynierskiej, zbudowaną w silniku **Unity 2022.3.40f1 (LTS)**. Aplikacja jest uruchamiana przy pomocy gogli **Meta Quest 3** połączonych z komputerem przy użyciu aplikacji **Meta Quest Link**.

---
## Film na YouTube
**Link: https://youtu.be/radFlIf2wII**


## Wizualizacja projektu

<p align="center">
  <img
    src="https://github.com/user-attachments/assets/1c565b71-c255-428d-bb89-c15660c9548a"
    alt="Wizualizacja projektu"
    width="690"
  >
</p>

<p align="center">
  ←
  <a href="https://github.com/user-attachments/assets/1c565b71-c255-428d-bb89-c15660c9548a">1</a>
  •
  <a href="https://github.com/user-attachments/assets/600d2635-42af-42fc-af1f-3f6c3cfc5316">2</a>
  •
  <a href="https://github.com/user-attachments/assets/c5cadf6c-12e1-472d-a3eb-d1390b956fe0">3</a>
  •
  <a href="https://github.com/user-attachments/assets/2c99ae31-e9a0-4b35-a73e-c32fbf649635">4</a>
  •
  <a href="https://github.com/user-attachments/assets/fb886ef2-b4c6-447f-9cef-3148a7a78ca2">5</a>
  •
  <a href="https://github.com/user-attachments/assets/d57e8d78-1326-460f-9938-c4a6e30d80dc">6</a>
  •
  <a href="https://github.com/user-attachments/assets/bd4ed5ad-601a-470b-a9ef-7f3fe2ee132a">7</a>
  •
  <a href="https://github.com/user-attachments/assets/ca3c7a7f-f794-4ea4-9d81-eb0273853e16">8</a>
  •
  <a href="https://github.com/user-attachments/assets/b40451af-9203-4e3d-8dce-0de505fca80b">9</a>
  •
  <a href="https://github.com/user-attachments/assets/6e9f8091-773b-4f16-a12c-31ec020219a9">10</a>
  •
  <a href="https://github.com/user-attachments/assets/ae1bc9d8-0118-4f8c-8522-60f3c8a18a44">11</a>
  •
  <a href="https://github.com/user-attachments/assets/ebc557f9-5d59-4e65-aa79-cd22a8413676">12</a>
  →
</p>
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

