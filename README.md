# Proyecto de Pruebas Unitarias en .NET y C# con xUnit

## **Descripción**
Este proyecto contiene el código base necesario para completar un curso sobre pruebas unitarias en .NET y C# utilizando **xUnit**. 

### **Instrucciones iniciales**
1. **Descarga del código:**
   - Clona o descarga este repositorio desde GitHub.
   - Usa el branch `master` o el branch `0-codigobase` como punto de partida.

2. **Ejecutar pruebas por consola:**
   ```bash
   dotnet test
   ```

---

## **Configuración de Coverlet para medición de cobertura**
Coverlet es una herramienta para analizar la cobertura de código de las pruebas unitarias.

### **Instalación de Coverlet.Console**
1. Ve a [nuget.org](https://www.nuget.org/) para verificar si la versión más reciente sigue siendo la misma.
2. Instala Coverlet.Console con el siguiente comando:
   ```bash
   dotnet tool install --global coverlet.console --version 6.0.3
   ```

### **Ejecutar pruebas con análisis de cobertura**
1. Ejecuta las pruebas incluyendo la medición de cobertura:
   ```bash
   dotnet test /p:CollectCoverage=true
   ```
2. Deberías ver una salida similar a esta:

   ```plaintext
   +--------------------+--------+--------+--------+
   | Module             | Line   | Branch | Method |
   +--------------------+--------+--------+--------+
   | StringManipulation | 25.74% | 20.83% | 66.66% |
   +--------------------+--------+--------+--------+

   +---------+--------+--------+--------+
   |         | Line   | Branch | Method |
   +---------+--------+--------+--------+
   | Total   | 25.74% | 20.83% | 66.66% |
   +---------+--------+--------+--------+
   | Average | 25.74% | 20.83% | 66.66% |
   +---------+--------+--------+--------+
   ```

### **Explicación de los términos:**
- **Line:** Cobertura de líneas del programa principal.
- **Branch:** Cobertura de los flujos de control del programa.
- **Method:** Métodos del código que tienen pruebas unitarias.

---

## **Generación de Reportes de Cobertura con ReportGenerator**
Para visualizar los resultados de la cobertura en un formato más accesible, como HTML, utiliza la herramienta **ReportGenerator**.

### **Instalación de ReportGenerator**
Antes de generar los reportes, asegúrate de instalar la herramienta globalmente:
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```
> **Nota:** Si este comando no se ejecuta, no podrás generar los reportes.

### **Generar el archivo XML de cobertura**
Primero, ejecuta las pruebas unitarias con Coverlet para generar el archivo de cobertura en formato Cobertura:
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./coverage/
```
Esto generará un archivo llamado `coverage.cobertura.xml` en el directorio `./coverage/`.

### **Generar el reporte en HTML**
Con el archivo `coverage.cobertura.xml`, ejecuta el siguiente comando:
```bash
reportgenerator "-reports:coverage/coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:Html
```

### **Explicación de los parámetros:**
- **-reports:** Ruta al archivo XML generado por Coverlet.
- **-targetdir:** Directorio donde se generarán los reportes en formato HTML.
- **-reporttypes:** Especifica los formatos de los reportes (en este caso, HTML).

### **Ubicación esperada de los archivos:**
- Asegúrate de que el archivo `coverage.cobertura.xml` esté en el directorio desde el cual ejecutas el comando `reportgenerator`. Si no está, utiliza una ruta absoluta o relativa correcta.
- El reporte HTML se generará en la carpeta especificada en el parámetro `-targetdir` (por ejemplo, `./coverage-report/`).

### **Visualizar el reporte:**
Abre el archivo `index.html` dentro del directorio generado (`coverage-report`) en tu navegador para ver los resultados de la cobertura.

---

## **Exclusión de cobertura por namespace**
Puedes excluir ciertos namespaces de la cobertura ejecutando el siguiente comando:
```bash
dotnet test /p:CollectCoverage=true /p:Include="[*]StringManipulation.*"
```

### **Exclusión de cobertura a nivel de clase o método**
También es posible excluir partes específicas del código agregando el atributo `[ExcludeFromCodeCoverage]` sobre las clases o métodos que desees omitir:

```csharp
[ExcludeFromCodeCoverage]
public class ClaseExcluida {
    public void MetodoExcluido() {
        // Código aquí
    }
}
```

---

## **Referencias útiles**
- [Documentación oficial de Coverlet](https://github.com/coverlet-coverage/coverlet)
- [Documentación oficial de ReportGenerator](https://github.com/danielpalme/ReportGenerator)
- [xUnit - Sitio Oficial](https://xunit.net/)
