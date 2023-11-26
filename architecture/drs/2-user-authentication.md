
# протокол аутентификации c пользовательским access token

## Context and Problem Statement
Веб гейтвей и моб гейтвей принимают запросы двух типов:
 - неавторизованные пользователи
 - авторизованные пользователи с сессионой кукой (asp.net cookie authentication), в случае моб приложения с access токеном

 MBFF приложение, является частью одной из систем.
Примеры систем:
  веб приложение
  мобильное приложение
  API с бизнес логикой (BasketMs)

часть MS-API работают с клиентской аутентификацией (OAUTH Client Credentials Grant) и требуют явной передачи id пользователя, в таком случае авторизация должна происходить на уровне BFF или WEBGATEWAY.

часть MS-API работают с пользовательским access token. В таком случае авторизация происходит на API гейтвее.

MBFF должны иметь возможность вызывать  MS-API используя пользовательский access token. 

## Considered Options

### прокидываем access_token в MBFF
* Bad ломается модель безопасности тк система MBFF получает доступ маскируясь под систему гейта.
### обмениваем access_token в случае если MBFF не принадлежит системе гейтвея
* Bad нужна поддержка Token Exchange на API гейте
* Bad доп. запрос, но результат можно кешировать 
### гейтвей выдает новый токен
* Bad нужен умный API гейт
* Bad генерация нового токена ресурсозатратна
## Decision Outcome

Chosen option: "{title of option 1}", because