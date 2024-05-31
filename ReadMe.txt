Przyciski:
światło i obiekt pozwalają użytkownikowi na zmianę kolorów odpowiednio światła i obiektu. 
Load texture i load map pozwalają na wgranie nowych plików textury i mapy wektorów normalnych

Ustawienia rysowania:
Całe trójkaty:
Wyznaczany jest kolor i trójkąt jest wypełniany
Jeżeli zaznaczony jest tryb korzystania z textury/mapy wektorów kolor każdego pixela jest wyznaczany odpowiednio.
Interpolacja koloru:
Wyznaczamy kolor w każdym wierzchołku (textura i mapa tylko w wierzchołkach) i jest interpolowany w trójkącie aby go odpowiednio wypełnić.
Interpolacja wektorów:
W każdym punkcie obliczamy  zinterpolowany wektor z  wierzchołków, a następnie przekształcamy go według mapy i obliczamy kolor.

Checkboxy zmieniają używanie textury/koloru obiektu i mapy wektorów
Stop zatrzymuje zegar, step powoduje przesunięcie zegara o 1, update rysuje dla obecnych ustawień bez przesunięcia źródła światła