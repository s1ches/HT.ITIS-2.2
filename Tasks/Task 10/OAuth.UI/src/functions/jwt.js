export function base64UrlDecode(str) {
    if (!str)
        return '';

    str = str.replace(/-/g, '+').replace(/_/g, '/');

    while (str.length % 4 !== 0)
        str += '=';

    return decodeURIComponent(escape(atob(str)));
}

export const getData = (claimType) => {
    const jwt = localStorage.getItem("identityToken");

    if(jwt == null) return null;

    const [_, encodedPayload, __] = jwt.split('.');

    const payload = JSON.parse(base64UrlDecode(encodedPayload));

    console.log(payload);

    return payload[claimType];
}