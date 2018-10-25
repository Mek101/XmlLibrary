######################################################################################################################
# Automatic git script, it pulls, add, commits and pushes all the sources on the current git repository              #
######################################################################################################################

pull=1
commit=1
push=1
comm_msg=()

# parse the command line parameters
for arg in $@; do
    echo $arg
    # switch the arguments
    case $arg in
        # disables the pull request first of all
        '-npl') pull=0   ;;
        # disables the commit (NOTE the commit message is ignored)
        '-ncm') commit=0 ;;
        # disables the push operation
        '-nps') push=0   ;;
        # other arguments are taked as the commit message
        *)
            # check whether the user have disabled the commit step
            if [ $commit -eq 0 ]; then
                echo "commit disabled"
                exit 1
            fi
            # copy the string
            comm_msg=( $comm_msg $arg )
            ;;
    esac
done

## first do the pull if requested
#if [ $pull -eq 1 ]; then
#    git pull origin master
#fi
#
## second do the commit
#if [ $commit -eq 1 ]; then
#    git add '.'
#    git commit -m $comm_msg
#fi
#
## then do the push
#if [ $push -eq 1 ]; then
#    git push origin master
#fi
