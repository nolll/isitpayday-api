function shouldFormatsAsFirst(n: number) {
    return endsWith(n, '1') && !endsWith(n, '11');
}

function shouldFormatsAsSecond(n: number) {
    return endsWith(n, '2') && !endsWith(n, '12');
}

function shouldFormatsAsThird(n: number) {
    return endsWith(n, '3') && !endsWith(n, '13');
}

function endsWith(n: number, lookFor: string) {
    return lastChar(n) === lookFor;
}

function lastChar(n: number) {
    return n.toString().slice(-1);
}

export default {
    format(n: number) {
        if (shouldFormatsAsFirst(n))
            return `${n}st`;
        if (shouldFormatsAsSecond(n))
            return `${n}nd`;
        if (shouldFormatsAsThird(n))
            return `${n}rd`;
        return `${n}th`;
    }
};
