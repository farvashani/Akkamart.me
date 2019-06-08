#!/usr/bin/env bash

sh build.sh

docker build -t akkamart-membership:${TAG:-latest} .
