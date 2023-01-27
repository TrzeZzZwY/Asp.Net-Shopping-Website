# Aplikacja sklep z rzeczami Handmade
Aplikacja symuluje dzia³anie sklepu. U¿ytkownicy mog¹ przegl¹daæ rzeczy, dodawaæ je do koszyka,
dodawaæ polubiebia oraz dodawaæ produkt do listy ¿yczeñ. Administrator mo¿e robiæ to co u¿ytkownik,
dodatkowo mo¿e dodawaæ oraz modyfikowaæ produkty oraz dodawaæ nowe kategorie.

Aplikacja zosta³a napisana w jêzyku c# z wykorzystaniem SQL Server

# Pierwsze uruchomienie
W pliku appsettings.json trzeba ustawiæ poprawny ContextConnection do naszej bazy danych. Nastêpnie nale¿y
wykonaæ migracje. W konsoli menagera pakietów NuGet nale¿y wprowadziæ
```sh
add-migration nazwaMigracji
update-database
```
Rola u¿ytkownika jest nadawana domyœlnie przy rejestracji, ale aby nadaæ komuœ uprawnienia administratora
nale¿y wykonaæ to polecenie w bazie danych
```sh
DECLARE @userId nvarchar(450);
DECLARE @roleId nvarchar(450);
DECLARE @userName nvarchar(256);

set @userName = 'nazwa_admina';
set @userId = (select Id from AspNetUsers where [UserName]=@userName);
set @roleId = (select Id from AspNetRoles where [Name]='admin');
insert into AspNetUserRoles values(@userId,@roleId);
```
w pole @userName nale¿y podaæ nazwê któr¹ podaliœmy podczas rejestracji. Aby rola zacze³a dzia³aæ nale¿y siê wylogowaæ i zalogowaæ.

# funkcjonalnoœci
## u¿ytkownik nie zalogowany
taka osoba mo¿e jedynie przegl¹daæ przedmioty w zak³adce sklep oraz galeria.
## u¿ytkownik zalogowany
mo¿e robiæ to samo co u¿ytkownik nie zalogowany oraz:

-Likowaæ przedmioty

-Dodawaæ do Listy ¿yczeñ

-Dodaæ do koszyka

-Zakupiæ rzeczy w koszyku

-Zmieniæ has³o

-Przegl¹daæ polubiane przedmioty

-Przegl¹daæ przedmioty z listy ¿yczeñ

-Przegl¹daæ przeg¹daæ historiê tranzakcji
## u¿ytkownik zalogowany jako administrator

mo¿e robiæ to samo co u¿ytkownik zalogowany oraz:

-Dodawaæ nowe produkty

-Modyfikowaæ produkty

-Dodawaæ kategoriê


# Api
Aplikacja posiada zimplementowane api dla encji item

# Testy jednostkowe

Aplikacja posiada testy najwa¿niejszych funkcji Kontrolera Api
