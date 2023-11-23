
# State Pattern -harjoitus

## Tehtävänanto
Tee ”Enemy” luokalle tilakone, joka sisältää tilat: Idle, Chasing, Attacking ja Fleeing. Hyödynnä state patternia eli jokaisen tilan täytyy olla oma luokkansa.

Toiminnallisuus voi olla seuraavanlainen: Idle voi olla oletustilana. ”Chasing” tilaan siirrytään kun pelaaja on riittävän kaukana (määrittele etäisyys itse). ”Attacking” tilaan siirrytään kun vihollinen on tarpeeksi lähellä pelaajaa. Vihollinen siirtyy ”Fleeing” tilaan, jos terveyspisteiden määrä tippuu alle 20. Tee jokaisesta tilasta siirtymät takaisin johonkin toiseen tilaan  niin ettei vihollinen jää jumiin mihinkään yhteen tilaan. Tarkista toimivuus ja tulosta tila aina esim. (Debug.Log()).

## Dokumentaatio

- Pelaaja:
  - Voi liikuttaa WASD- tai nuolinäppäimillä.
  - Voi hyökätä painamalla välilyöntiä.
- Vihollinen:
  - Liikkuu pelaajan perässä, hyökkää pelaajan kimppuun jos pelaaja tulee riittävän lähelle.
  - Pakenee kun sen terveyspisteet ovat < 20.
  - Terveyspisteet nousevat ajan mukaan.
    - Palaa takaisin pelaajan perään kun sen terveyspisteet ovat > 20.