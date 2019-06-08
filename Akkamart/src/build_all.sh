echo $(pwd)
echo "========================================"
pwd
cd Akkamart.Home/
sh build_docker.sh
cd  ../..

echo "========================================"
echo $(pwd)
echo "========================================"
pwd
cd src/Akkamart.Membership/
sh build_docker.sh
echo "========================================"
echo $(pwd)
echo "========================================"
pwd
cd src/Akkamart.Seed1/
sh build_docker.sh
echo "========================================"
