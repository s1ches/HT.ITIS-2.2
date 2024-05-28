import React from 'react';
import prikol1 from '../../assets/prikol1.jpg'
import prikol2 from '../../assets/prikol2.jpg'
import prikol3 from '../../assets/prikol3.jpg'
import prikol4 from '../../assets/prikol4.jpg'
import prikol5 from '../../assets/prikol5.jpg'
import prikol6 from '../../assets/prikol6.jpg'


const ImagesPage = () => {
    return (
        <div>
            <h1>Jokes</h1>
            <div>
                <img src={prikol1} alt=''/>
                <img src={prikol2} alt=''/>
                <img src={prikol3} alt=''/>
                <img src={prikol4} alt=''/>
                <img src={prikol5} alt=''/>
                <img src={prikol6} alt=''/>
            </div>
        </div>
    );
};

export default ImagesPage;