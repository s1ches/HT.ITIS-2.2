export const getUserName = (jwt) => {
    if(jwt == null) return null;
    let payload = getPayload(jwt);
    return payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
}

const getPayload = (jwt) => {
    if(jwt == null) return null;

    const [_, encodedPayload, __] = jwt.split('.');

    const payload = JSON.parse(base64UrlDecode(encodedPayload));

    if(!payload) return null;

    return payload;
}

export const getUserRole = (jwt) => {
    if(jwt == null) return null;
    let payload = getPayload(jwt);
    return payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
}

function base64UrlDecode(str) {
    if (!str)
        return '';

    str = str.replace(/-/g, '+').replace(/_/g, '/');

    while (str.length % 4 !== 0)
        str += '=';

    return decodeURIComponent(escape(atob(str)));
}