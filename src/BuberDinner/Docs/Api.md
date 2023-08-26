# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "David",
  "lastName": "Lopera",
  "email": "dlopera@email.com",
  "password": "Pwd1234!"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "062996c0-5afe-45c7-af4a-ed3d2ddfa5d6",
  "firstName": "David",
  "lastName": "Lopera",
  "email": "dlopera@email.com",
  "token": "eyJ0eXAiOiJK.....XsuWty8"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "dlopera@email.com",
  "password": "Pwd1234!"
}
```

#### Login Response

```js
200 OK
```

```json
{
  "id": "062996c0-5afe-45c7-af4a-ed3d2ddfa5d6",
  "firstName": "David",
  "lastName": "Lopera",
  "email": "dlopera@email.com",
  "token": "eyJ0eXAiOiJK.....XsuWty8"
}
```