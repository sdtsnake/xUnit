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
- [xUnit - Sitio Oficial](https://xunit.net/)
