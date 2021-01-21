# Koombia.Mobile.Tests

Proyecto de pruebas que usa StacFlows y Appium en C# y está construido implementando page object pattern (POM)

La solución contiene dos proyectos, uno con el framework de automation y el otro con las pruebas como tal.
En el framework se puede encontrar la siguiente estructura:
Common: contiene clases genéricas para el manejo de logs y gestión de variables de pruebas.
Containers: contiene el AppContainer desde el cual se centraliza el acceso al Driver (AppiumDriver)
Extensions: contiene algunas extensiones para la clase AppiumWebElement
Screens: contiene la clase base para todas las screen que tenga el proyecto. acá se encuentran métodos genéricos como scroll, swipe, etc.

El proyecto de pruebas contiene lo siguiente:
Features: contiene las features donde se definen los escenarios de prueba en lenguaje Gherkin.
Initializer: contiene el test inicializer con las precondiciones y las postcondiciones de ejecución.
Resources: acá se guardan recursos necesarios para la ejecución, en este caso el apk
ScreenObjects: Acá deben ir todos los objetos necesarios para el page object pattern, en este caso sólo se definió una pantalla.
StepDefinitions: contiene los pasos asociados a la feature
appsettings.json: contiene las variables de configuración de la prueba.

Para ejecutar localmente en una máquina windows se debe realizar la siguiente configuración.
- Descargar Visual Studio (yo usé VS 2019)
- Instalar la extensión SpecFlow for Visual Studio
- Instalar un emulador o conectar un dispositivo android vía usb con opción de debug habilitada.
- Instalar Node.js en la máquina
- Instalar Appium server
- Levantar el servidor de appium (en consola escribir appium)
