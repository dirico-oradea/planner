import { makeStyles } from "@mui/styles";

const useStyles = makeStyles({
    footer: {
        textShadow: '4px 4px 4px #000'
    }
});

export const Footer = () => {
    const classes = useStyles();
    return (
        <footer className={classes.footer}>
            footer with JSS - makeStyles
        </footer>
    )
}