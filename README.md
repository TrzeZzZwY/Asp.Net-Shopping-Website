# Aplikacja sklep z rzeczami Handmade
Aplikacja symuluje dzia�anie sklepu. U�ytkownicy mog� przegl�da� rzeczy, dodawa� je do koszyka,
dodawa� polubiebia oraz dodawa� produkt do listy �ycze�. Administrator mo�e robi� to co u�ytkownik,
dodatkowo mo�e dodawa� oraz modyfikowa� produkty oraz dodawa� nowe kategorie.

Aplikacja zosta�a napisana w j�zyku c# z wykorzystaniem SQL Server

# Pierwsze uruchomienie
W pliku appsettings.json trzeba ustawi� poprawny ContextConnection do naszej bazy danych. Nast�pnie nale�y
wykona� migracje. W konsoli menagera pakiet�w NuGet nale�y wprowadzi�
```sh
add-migration nazwaMigracji
update-database
```
Rola u�ytkownika jest nadawana domy�lnie przy rejestracji, ale aby nada� komu� uprawnienia administratora
nale�y wykona� to polecenie w bazie danych
```sh
DECLARE @userId nvarchar(450);
DECLARE @roleId nvarchar(450);
DECLARE @userName nvarchar(256);

set @userName = 'nazwa_admina';
set @userId = (select Id from AspNetUsers where [UserName]=@userName);
set @roleId = (select Id from AspNetRoles where [Name]='admin');
insert into AspNetUserRoles values(@userId,@roleId);
```
w pole @userName nale�y poda� nazw� kt�r� podali�my podczas rejestracji. Aby rola zacze�a dzia�a� nale�y si� wylogowa� i zalogowa�.

# funkcjonalno�ci
## u�ytkownik nie zalogowany
taka osoba mo�e jedynie przegl�da� przedmioty w zak�adce sklep oraz galeria.
## u�ytkownik zalogowany
mo�e robi� to samo co u�ytkownik nie zalogowany oraz:

-Likowa� przedmioty

-Dodawa� do Listy �ycze�

-Doda� do koszyka

-Zakupi� rzeczy w koszyku

-Zmieni� has�o

-Przegl�da� polubiane przedmioty

-Przegl�da� przedmioty z listy �ycze�

-Przegl�da� przeg�da� histori� tranzakcji
## u�ytkownik zalogowany jako administrator

mo�e robi� to samo co u�ytkownik zalogowany oraz:

-Dodawa� nowe produkty

-Modyfikowa� produkty

-Dodawa� kategori�


# Api
Aplikacja posiada zimplementowane api dla encji item

# Testy jednostkowe

Aplikacja posiada testy najwa�niejszych funkcji Kontrolera Api
