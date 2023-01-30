#! /bin/bash

killpids=$(pgrep -f "dotnet run --project")
kill $killpids
