#sudo journalctl -f -k
# Kuralları temizle
sudo iptables -F FORWARD

sudo iptables -A FORWARD -i eth0 -m string --string "nesine"  --algo bm -j LOG --log-prefix "DROP: "
sudo iptables -A FORWARD -i eth0 -m string --string "nesine"  --algo bm -j DROP
sudo iptables -A FORWARD -i eth0 -m string --string "com"  --algo bm -j LOG --log-prefix "NEW: "

# Genel kurallar
sudo iptables -A FORWARD -i eth0 -o wlan0 -j ACCEPT
sudo iptables -A FORWARD -i wlan0 -o eth0 -m state --state RELATED,ESTABLISHED -j LOG --log-prefix "ACCEPT: "
sudo iptables -A FORWARD -i wlan0 -o eth0 -m state --state RELATED,ESTABLISHED -j ACCEPT

# Bağlantıları temizle
sudo conntrack -F
