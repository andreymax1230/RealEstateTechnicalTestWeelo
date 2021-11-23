# RealEstateTechnicalTestWeelo
Prueba técnica Weelo

# Diseño
La prueba técnica se desarrollo con arquitectura limpia, utilizando MediaTR como la biblioteca de mensajería entre la capa de aplicación y el api, fluent validate para validar los modelos, AutoMapper para mapear las propiedades del dominio y poder representarlas en objetos para transportar datos(DTO) y por ultimo UnitTest para realizar pruebas unitarias 

# MER de la base de datos
![MER](https://user-images.githubusercontent.com/67155415/142960955-3e3035cd-6350-4e92-bf94-64ca389e911f.PNG)
# Ejecución
El proyecto utiliza una metodología llamada code first que en base en las clases que se define en el proyecto genera la base de datos 
Antes de ejecutar el proyecto es necesario que el servidor de base de datos tenga la autenticación mixta 
![AutenticacionMixta](https://user-images.githubusercontent.com/67155415/142961295-c8100824-1123-40cc-b6f7-cd32ff80485c.PNG)

Crear un login de usuario en la BD, con opción sql server authentication

![LoginUsuario](https://user-images.githubusercontent.com/67155415/142961371-6c13c971-d89a-4091-9e10-028c0370a574.PNG)

En la parte de server Roles, agregar la opción de sysadmin

![LoginPermisos](https://user-images.githubusercontent.com/67155415/142961523-a114576c-86d1-4a8a-9ad3-45db5493c2d7.PNG)

Por último en la cadena de conexión modificar el usuario y password configurados previamente

![UsuarioBD](https://user-images.githubusercontent.com/67155415/142961612-07e20656-141b-4eb5-9dec-3fdd99b598c2.PNG)
