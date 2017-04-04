#!/usr/bin/env bash
set -e
set -x
set -o errexit

DOCS_DIR="../docs"


fixup_file() {
    FILE=$1
    # Get <head> on its own line
    sed -E $'s/<head>/\\\n<head>\\\n/' "$FILE" > "$FILE.tmp" && mv "$FILE.tmp" "$FILE"

    sed -E '/^<head>$/r gtm-header.txt' "$FILE" > "$FILE.tmp" && mv "$FILE.tmp" "$FILE"

    sed -E '/^<head>$/r gtm-data-layer.txt' "$FILE" > "$FILE.tmp" && mv "$FILE.tmp" "$FILE"

    sed -E $'s/<body[^>]*>/\\\n&\\\n/' "$FILE" > "$FILE.tmp" && mv "$FILE.tmp" "$FILE"
    sed -E '/^<body[^>]*>$/r gtm-body.txt' "$FILE" > "$FILE.tmp" && mv "$FILE.tmp" "$FILE"
}

# fixup_file "$DOCS_DIR/html/R_Project_smartsheet-csharp-sdk-docs.htm"
for filename in $DOCS_DIR/html/*.htm
do
        fixup_file $filename
done


