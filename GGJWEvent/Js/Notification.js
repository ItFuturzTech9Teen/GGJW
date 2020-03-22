var CreateNotification = function(vheading,vmessage,type)
{
    if (type == 1)
    {
        $.toast({
            heading: vheading,
            text: vmessage,
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 3500,
            stack: 6
        });
    }
    else if (type == 2)
    {
        $.toast({
            heading: vheading,
            text: vmessage,
            position: 'top-right',
            loaderBg: '#ff6849',
            icon: 'error',
            hideAfter: 3500

        });
    }
}