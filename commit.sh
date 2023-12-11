AZUSERNAME=$AZUSERNAME
AZUSER_EMAIL=$AZUSER_EMAIL
AZORG=$AZORG
GHUSER=$GHUSER
GHPAT=$GHPAT

git config --global user.email "$AZUSER_EMAIL"
git config --global user.name "$AZUSERNAME"

git clone https://$GHUSER:$GHPAT@github.com/$GHUSER/Moonglade-$GHUSER ./Moonglade-gh
GIT_CMD_REPOSITORY="https://$AZUSERNAME:$AZUREPAT@dev.azure.com/$AZORG/Moonglade/_git/Moonglade"
git clone $GIT_CMD_REPOSITORY ./Moonglade-az-develop
git clone $GIT_CMD_REPOSITORY ./Moonglade-az-master

echo "Checking out master"
pushd Moonglade-az-master
git checkout master
rm -rf .git
popd

echo "Checking out develop"
pushd Moonglade-az-develop
git checkout develop
rm -rf .git
popd

echo "Copying new stuff from Azure dev to Github"
cp -r Moonglade-az-master/* Moonglade-gh/

pushd Moonglade-gh
git checkout main
echo "Copying new stuff from Azure master to Github"
git add .
git commit -m "sync master from azure to github"
git push

git checkout develop
cp -r ../Moonglade-az-develop/* .
echo "Copying new stuff from Azure dev to Github"
git add .
git commit -m "sync master from azure to github"
git push
popd
