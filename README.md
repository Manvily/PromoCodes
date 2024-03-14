# PromoCodes

Wszystko dodałem w jednym commicie z uwagi na rozmiar aplikacji, ale w normalnym stanie każdą funkcjonalność puszczałbym w osobnym branchu, odpalał przez code review i domergowywal do mastera. Oczywiście brakuje tutaj szczegółowej walidacji jak i testów - zdaję sobię z tego sprawę jednak takie zadanie powinno mieć swój rozmiar.



są 4 endpointy
- GET - Pobiera kod jeżeli istnieje i zminejsza jego counter do wyświetlania
- PATCH - Możliwość zmiany dwóch pól (isActive oraz name), każda zmiana jest rejestrowana w osobnej tabeli ale nie ma endpointu do podglądu tych zmian
- POST - Tworzy nowy kod jeżeli nie istnieje
- DELETE - usuwa kod jeżeli istnieje
wszystkie endpointy są dostępne w swaggerze /swagger/index.html

Pozostałe:
- sqlite
- .NET 6
- Swagger
- AutoMapper
- Entity Framework
- Repository pattern
- ViewModel pattern
- Unit of work pattern
- Custom exceptions
- Dependency Injection 

W repo jest baza danych więc wystarczy odpalić apkę, natomiast jak chcemy baze od nowa postawić to trzeba pierw odpalić istniejące migracje.
