@echo off
csc /target:winexe /out:bin/pong.exe *.cs
cd bin
pong
