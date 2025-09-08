#!/bin/bash

# git tag v
# git push --tags
TAG="$1"
if [[ -z "$TAG" ]]; then
  echo "Использование: ./release.sh. Введите параметр <TAG>"
  exit 1
fi

FILES=(
"./EquipListLib/bin/Release/net9.0/linux-x64/native/EquipListLib.so" 
"./EquipListLib/bin/Release/net9.0/linux-x64/native/EquipListLib.so.dbg" "README.md"
)
for file in "${FILES[@]}"; do
  if [[ ! -f "$file" ]]; then
    echo "Файл не найден: $file"
    exit 1
  fi
done

gh release create "$TAG" "${FILES[@]}"
echo "Релиз $TAG опубликован с файлами(если не ctrl+c): ${ASSETS[*]}"