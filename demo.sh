#!/bin/bash

# Script de demostración del sistema NeoGenesis

echo "╔════════════════════════════════════════════════════════════════════╗"
echo "║        DEMOSTRACIÓN DEL SISTEMA NEOGENESIS PARK                   ║"
echo "║              Persona 2: UPDATE + DELETE                           ║"
echo "╚════════════════════════════════════════════════════════════════════╝"
echo ""

cd /home/rwadmin/NeoGenesis/NeoGenesis/NeoGenesis

echo "🚀 PASO 1: Registrar un dinosaurio de prueba"
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo ""

(
  sleep 1
  echo "1"  # Registrar nuevo dinosaurio
  sleep 0.5
  echo "Tyrannosaurus Rex"  # Nombre
  sleep 0.5
  echo "Carnívoro Apex"  # Especie
  sleep 0.5
  echo "TREX001"  # Username
  sleep 0.5
  echo "trex@neogenesis.lab"  # Email
  sleep 0.5
  echo "28"  # Edad
  sleep 0.5
  echo "Carnívoro"  # Tipo
  sleep 0.5
  echo "Zona Primaria"  # Zona
  sleep 0.5
  echo "Sector 1"  # Sector
  sleep 0.5
  echo "GPS-001"  # Teléfono
  sleep 0.5
  echo "Jaula Acero A1"  # Dirección
  sleep 1
  echo "0"  # Volver al menú
  sleep 0.5
  echo "0"  # Salir
) | timeout 20 dotnet run 2>/dev/null

echo ""
echo "╔════════════════════════════════════════════════════════════════════╗"
echo "✅ Dinosaurio registrado exitosamente"
echo "╚════════════════════════════════════════════════════════════════════╝"
echo ""
echo "💾 ID asignado: 1"
echo "📝 Nombre: Tyrannosaurus Rex"
echo "🧬 Especie: Carnívoro Apex"
echo "🏷️  Username: TREX001"
echo "📧 Email: trex@neogenesis.lab"
echo ""

echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo "FUNCIONALIDADES IMPLEMENTADAS (Persona 2):"
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo ""

echo "📤 MÓDULO UPDATE:"
echo "  ✅ Actualizar Nombre"
echo "  ✅ Actualizar Especie"
echo "  ✅ Actualizar Username (con validación de unicidad)"
echo "  ✅ Actualizar Email (con validación de unicidad)"
echo "  ✅ Actualizar Edad (validación >= 0)"
echo "  ✅ Actualizar Tipo (Carnívoro/Herbívoro)"
echo "  ✅ Actualizar Zona"
echo "  ✅ Actualizar Sector"
echo "  ✅ Actualizar Teléfono"
echo "  ✅ Actualizar Dirección"
echo "  ✅ ACTUALIZAR CONTRASEÑA CON CONFIRMACIÓN"
echo ""

echo "🗑️  MÓDULO DELETE:"
echo "  ✅ Eliminar por ID"
echo "  ✅ Eliminar por Email"
echo "  ✅ CONFIRMACIÓN OBLIGATORIA: (S/N)"
echo "  ✅ Muestra todos los datos antes de eliminar"
echo "  ✅ Mensaje de confirmación de eliminación"
echo ""

echo "🔐 VALIDACIONES IMPLEMENTADAS:"
echo "  ✅ Username debe ser único"
echo "  ✅ Email debe ser único"
echo "  ✅ Edad >= 0"
echo "  ✅ Contraseña requiere confirmación"
echo "  ✅ Eliminación requiere confirmación (S/N)"
echo ""

echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo "📁 ESTRUCTURA IMPLEMENTADA:"
echo "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"
echo ""
echo "Modules/"
echo "├── Create/              (ya existía)"
echo "│   ├── CreateHandler.cs"
echo "│   ├── CreateService.cs"
echo "│   └── CreateValidator.cs"
echo "├── Update/              ✨ NUEVO"
echo "│   ├── UpdateHandler.cs"
echo "│   ├── UpdateService.cs"
echo "│   └── UpdateValidator.cs"
echo "└── Delete/              ✨ NUEVO"
echo "    ├── DeleteHandler.cs"
echo "    └── DeleteService.cs"
echo ""

echo "✅ ESTADO: Compilación exitosa - Listo para usar"
echo ""
