import { useEffect ,useState} from "react";
const baseURL = "http://localhost:5136/sectors";
const useGetSectors = () =>{
    const[Sectors, setSectors] = useState([]);
    const getApiData = async () => {
        const response = await fetch(
          "http://localhost:5136/sectors"
        ).then((response) => response.json());
    
        const prepareTree = (arr = [], root = null) => {
          let res;
          const obj = Object.create(null);
          arr.forEach(el => {
             el.children = obj[el.sectorID] && obj[el.sectorID].children;
             obj[el.sectorID] = el;
             if (el.parentSectorID === root) {
                res = el;
             }
             else {
                obj[el.parentSectorID] = obj[el.parentSectorID] || {};
                obj[el.parentSectorID].children = obj[el.parentSectorID].children || [];
                obj[el.parentSectorID].children.push(el);
             }
          });
       return res;
       };
       const sorting = (arr =[])=>{
        let sorted = [];
         response.sort(x=>x.sectorID).forEach(item=>{
           if(item.parentSectorID === null)
            {
              sorted.push(item);
            }
            else
            {
              const index = sorted.map(e => e.sectorID).indexOf(item.parentSectorID);
              if(index > -1)
              {
                var subCount = sorted[index].name.lastIndexOf("-");
                var subReprestnationChar = '-';
                var subReprestional = subReprestnationChar.repeat(subCount+4);
                item.name = subReprestional + item.name
                sorted.splice(index,0,item);
              }
            }
          });
          return sorted.sort(x=>x.sectorID);
        }
       const attempt = sorting(response);
       attempt.reverse();
       setSectors(attempt);

      };
      useEffect(() => {
        getApiData();
      }, []);
    return Sectors;
}
export default useGetSectors;